using BakeryIS.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BakeryIS.adminbakery
{
    internal class adbakery
    {
        public List<Infobakery> Bakerys { get; set; }
        private string _path;
        public adbakery(string path)
        {
            _path = path;
            Bakerys = gBakery();
        }
        public void file()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Bakerys);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Infobakery> gBakery()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<Infobakery> rec = formatter.Deserialize(fs) as List<Infobakery>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<Infobakery>();
                }
            }
            catch (SerializationException)
            {
                return new List<Infobakery>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string name, string structure, string calories, string price, string time)
        {
            Bakerys.Add(new Infobakery(name, structure, calories, price, time));
            try
            {
                file();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}