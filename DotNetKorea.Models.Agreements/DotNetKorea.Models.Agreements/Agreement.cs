namespace DotNetKorea.Models.Agreements
{
    /// <summary>
    /// 약관(동의;Agreements) 테이블
    /// 이용 약관에 들어갈 문구를 한국어/영어로 나눠서 관리하는 테이블
    /// 한국어일 때에는 AgreementText가 보여지고 영어 버전일 때에는 AgreementEng가 보여짐
    /// </summary>
    public class Agreement
    {
        public int AgreementId { get; set; }
        public string AgreementText { get; set; }
        public string AgreementEng { get; set; }
    }
}
