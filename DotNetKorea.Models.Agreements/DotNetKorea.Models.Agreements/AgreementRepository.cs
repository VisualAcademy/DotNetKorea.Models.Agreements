using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DotNetKorea.Models.Agreements
{
    /// <summary>
    /// AgreementRepository : Agreement 클래스와 Agreements 테이블에 대한 CRUD 구현
    /// </summary>
    public class AgreementRepository : IAgreementRepository
    {
        private readonly IDbConnection db = new SqlConnection();
        private string _connectionString;

        public AgreementRepository(string connectionString)
        {
            _connectionString = connectionString;
            db = new SqlConnection(connectionString);
        }

        public Agreement Add(Agreement aggrement)
        {
            var sql = " INSERT INTO Agreements (AgreementText, AgreementEng) Values (@AgreementText, @AgreementEng); "
                    + " SELECT CAST(SCOPE_IDENTITY() As Int) ";
            var id = db.Query<int>(sql, aggrement).Single();
            aggrement.AgreementId = id;
            return aggrement;
        }

        public List<Agreement> GetAll() => db.Query<Agreement>("SELECT * FROM Agreements Order By AgreementId Desc").ToList();

        public Agreement Find(int id)
        {
            return db.Query<Agreement>("SELECT * FROM Agreements WHERE AgreementId = @AgreementId", new { id }).SingleOrDefault();
        }

        public Agreement Update(Agreement aggrement)
        {
            var sql = " UPDATE Agreements " +
                        " SET AgreementText = @AgreementText, " +
                        "     AgreementEng = @AgreementEng " +
                        " WHERE AgreementId = @AgreementId ";

            db.Execute(sql, aggrement);
            return aggrement;
        }

        public void Remove(int id) => db.Execute("DELETE FROM Agreements WHERE AgreementId = @AgreementId", new { id });

        // 가장 최근 약관
        public Agreement GetRecentlyAgreement()
        {
            return db.Query<Agreement>("SELECT Top 1 * FROM Agreements Order By AgreementId Desc").SingleOrDefault();
        }
    }
}
