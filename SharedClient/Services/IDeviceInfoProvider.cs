using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranscendenceChat.Services
{
    public interface IDeviceInfoProvider
    {
        Task<List<string>> GetUserDevices(long userId);

        Task<Dictionary<string, string>> GetUserDevicesAndPublicKeys(int userId);

        Task SavePublicKeyForDeviceId(string deviceId, long userId, string publicKey);
    }
}
