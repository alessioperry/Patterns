using System;

namespace Tests.Code
{
    class LogAnalyzer
    {
        private bool wasLastFileNameValid;

        public bool WasLastFileNameValid
        {
            get { return wasLastFileNameValid; }
            set { wasLastFileNameValid = value; }
        }

        public bool IsValidLogFileName(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName)) {
                wasLastFileNameValid = false;
                throw new ArgumentException("Invalid file name");
            }

             if (!fileName.ToLower().EndsWith(".slf")) 
                 return wasLastFileNameValid = false;

             return wasLastFileNameValid = true;
       }
    }
}
