using System.Collections.Generic;

namespace DotNetKorea.Models.Agreements
{
    public interface IAgreementRepository
    {
        Agreement Add(Agreement aggrement);
        Agreement Find(int id);
        List<Agreement> GetAll();
        Agreement GetRecentlyAgreement();
        void Remove(int id);
        Agreement Update(Agreement aggrement);
    }
}