using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTranslation
{
    [Serializable]
    public class Translation
    {
        private string _responseData = "";
        private string _translatedText = "";
        private string _responseDetails = "";
        private string _responseStatus = "";

        public string ResponseData { get { return _responseData; } set { _responseData = value; } }
        public string TranslatedText { get { return _translatedText; } set { _translatedText = value; } }
        public string ResponseDetails { get { return _responseDetails; } set { _responseDetails = value; } }
        public string ResponseStatus { get { return _responseStatus; } set { _responseStatus = value; } }

        public Translation() { }
    }

    public class TranslationCollection : System.Collections.CollectionBase
    {
        public Translation Item(int index)
        {
            return (Translation)List[index];
        }

        public void Add(Translation item)
        {
            List.Add(item);
        }

        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                System.Windows.Forms.MessageBox.Show("Index not valid on incoming translation. Contact support.");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
    }
}
