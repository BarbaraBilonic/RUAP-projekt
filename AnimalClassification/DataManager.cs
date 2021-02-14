using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Classification
{
    class DataManager
    {
        private APIManager apiManager;
        private List<string> data;
        private string[] types = new string[] { "Mammal", "Bird", "Reptile", "Fish", "Amphibian", "Insect", "invertebrate" };

        public DataManager()
        {
            apiManager = APIManager.getInstance();
            data = new List<string>();
        }

        public string determineAnimalType(string result)
        {
            string typeClass = result[result.Length-8].ToString();
            int index = int.Parse(typeClass);
            index--;
            string type = types[index];
            return type;
        }
        public string getAnimalType()
        {
            List<List<string>> values = new List<List<string>>();
            values.Add(data);
            values.Add(data);
            string result = apiManager.InvokeRequestResponseService(values).Result;
            data.Clear();
            return determineAnimalType(result);
        }

       

        public void addDataItem(string dataItem)
        {
            if (dataItem == "Yes")
            {
                dataItem = "1";
            }
            if (dataItem == "No")
            {
                dataItem = "0";
            }
            data.Add(dataItem);
        }
       
    }
}
