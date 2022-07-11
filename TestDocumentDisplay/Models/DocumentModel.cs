namespace TestDocumentDisplay.Models
{
    public class DocumentModel
    {
        public byte[] DocumentBytes { get; set; }
        public string DocumentName { set; get; }
        public int? DocumentFormat { set; get; }

        public void SetFormat()
        {
            string Ext = DocumentName.Split('.')[DocumentName.Split('.').Length - 1];
            switch (Ext)
            {
                case "txt":
                    DocumentFormat = 1;
                    break;
                case "rft":
                    DocumentFormat = 2;
                    break;
                case "doc":
                case "docx":
                    DocumentFormat = 3;
                    break;
                default:
                    break;
            }
        }
    }
}
