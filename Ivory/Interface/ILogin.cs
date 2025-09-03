using Ivory.Models;

namespace Ivory.Interface
{
    public interface ILogin
    {
        bool MobileExists(long mobile);
        void Add(Register model);
        void Save();


        Register GetUserByMobile(long mobile);
        void SaveOTP(Login loginEntry);
        void SaveChanges();


        Login GetLatestValidLoginEntry(int shopId);
        void InvalidateOTP(Login loginEntry);

        void ExpireOtp();

        void LogUserLogout(int shopId);

    }
}

