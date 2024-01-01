using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTask
{
    public class UseData
    {
        public DataTable csvData { get; set; }

        public DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return csvData;
        }
        public double FindAvarageAge()
        {
            var avarage = csvData.AsEnumerable().
                Average(r => Convert.ToDouble(r.Field<string>("Age")));
            return avarage;
        }
        public int FindTotalNumberOfSpecificPeople()
        {
            int sum = csvData.AsEnumerable()
                .Count(r => Convert.ToDouble(r.Field<string>("Weight")) >= 120 && Convert.ToDouble(r.Field<string>("Weight")) <= 140);
            return sum;
        }
        public double FindAvarageOfSpecificPeople()
        {
            var avarage = csvData.AsEnumerable().
                Where(r => Convert.ToDouble(r.Field<string>("Weight")) >= 120 && Convert.ToDouble(r.Field<string>("Weight")) <= 140).
                Average(r => Convert.ToDouble(r.Field<string>("Age")));
            return avarage;
        }

    }
}
