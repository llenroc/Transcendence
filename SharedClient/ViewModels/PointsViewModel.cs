using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TranscendenceChat
{
	public class PointsViewModel : BaseViewModel
	{
		readonly IDataManager dataManager = App.DataManager;

		public string LoadingMessage { get; set; }

		readonly SemaphoreSlim taskSemaphore = new SemaphoreSlim (1);
		readonly BatchUpdateObservableCollectoin<TranscendenceTask> tasks = new BatchUpdateObservableCollectoin<TranscendenceTask>();

		public BatchUpdateObservableCollectoin<TranscendenceTask> Tasks {
			get {
				return tasks;
			}
		}

		public SemaphoreSlim TaskSemaphore {
			get {
				return taskSemaphore;
			}
		}

		int points = -1;
		public const string PointsPropertyName = "Points";

		public int Points {
			get {
				if (points < 0)
					points = Settings.TranscendencePoints;
				return points;
			}
			set {
				Settings.TranscendencePoints = value;
				SetProperty (ref points, value, PointsPropertyName);
			}
		}

		int pendingPoints = -1;
		public const string PendingPointsName = "PendingPoints";

		public int PendingPoints {
			get {
				if (pendingPoints < 0)
					pendingPoints = Settings.TranscendencePointsPending;

				return pendingPoints;
			}
			set {
				Settings.TranscendencePointsPending = value;
				SetProperty (ref pendingPoints, value, PendingPointsName);
			}
		}

		ICommand loadTranscendenceTasks;

		public ICommand LoadTranscendenceTasks {
			get {
				return loadTranscendenceTasks ?? (loadTranscendenceTasks = new RelayCommand (() => {
				}));
			}
		}

		public async Task ExecuteLoadTranscendenceTasksCommand ()
		{
			if (IsBusy)
				return;

			LoadingMessage = "Loading tasks...";

			using (BusyContext ()) {
				using (App.Logger.TrackTimeContext ("LoadingTasks")) {
					try {
						var TranscendenceTasks = await dataManager.GetTranscendenceTaskAsync ().ConfigureAwait(false);
						await LoadToCollection (TranscendenceTasks);
						await RecalculatePoints ().ConfigureAwait (false);
					} catch (Exception ex) {
						App.Logger.Report (ex);
						RaiseError ("Failed to load tasks");
					}
				}
			}
		}

		async Task RecalculatePoints ()
		{
			await TaskSemaphore.WaitAsync ().ConfigureAwait (false);

			int pending = 0;
			foreach (var t in Tasks) {
				if (!t.IsPending)
					continue;

				pending += t.Points;
				t.IsPending = false;
				await dataManager.AddOrSaveTranscendenceTaskAsync (t).ConfigureAwait (false);
			}

			TaskSemaphore.Release ();

			Points = Points + pending;
			PendingPoints = 0;
		}

		async Task LoadToCollection (IEnumerable<TranscendenceTask> items)
		{
			await TaskSemaphore.WaitAsync ().ConfigureAwait (false);

			using (Tasks.UpdatesBlock ()) {
				Tasks.Clear ();
				Tasks.AddRange (items);
			}

			TaskSemaphore.Release ();
		}

		public void Apply (TranscendenceTask task)
		{
			if (task.IsPending)
				PendingPoints = PendingPoints - task.Points;
			else
				PendingPoints = PendingPoints + task.Points;

			task.IsPending = !task.IsPending;
			dataManager.AddOrSaveTranscendenceTaskAsync (task);
		}
	}
}

