using System.Collections.Generic;
using System.IO;

namespace Santi.Federico._4H.SaveRecords.Models
{
    public class Comune
    {
        public int ID{get; set;}
        public string NomeComune{get;set;}
        public string CodiceCastale{get;set;}
        public Comune(){}
        public Comune(string riga, int id)
        {
            string [] colonne = riga.Split(',');
            
            ID = id;
            NomeComune = colonne[2];
            CodiceCastale = colonne[1];
            

        }
    }
    public class Comuni : List<Comune> // Comuni è una list<comune>
    {
        public string Nomefile {get;}
        public Comuni() {}
        public Comuni(string fileName)
        {
         Nomefile = fileName;
            using (FileStream fin = new FileStream(fileName, FileMode.Open))
            {
                StreamReader reader = new StringReader(fin);
                
                int id = 1;
                while(!reader.EndOfStream)
                {
                    string riga = reader.ReadLine();
                    Comune c = new Comune(riga,id);
                    
                    Add(c);


                }
            }
        }
        public void save()
        {
            string  fileName = Nomefile.Split(".")[0] + "bin";
        }
        public void save(string fileName)
        {
            
            FileStream fout = new FileStream("fileName", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fout);
            foreach(Comune comune in this)
            {
                writer.Write(comune.ID);
                writer.Write(comune.NomeComune);
                writer.Write(comune.CodiceCastale);
            }
            writer.Flush();
            writer.Close();
        }
        public void Load()
        {
            string fn = Nomefile.Split(".")[0]+ "bin";
            Load(fn);
        }
        public void Load(string fileName)
        {
            FileStream fin = new FileStream(fileName,FileMode.Open);
            BinaryReader reader = new BinaryReader(fin);
            Comune c = new Comune();
             c.ID = reader.ReadInt32();
             c.CodiceCastale = reader.ReadString();
 
            c.NomeComune = reader.ReadString();
            Add(c);
             c.ID = reader.ReadInt32();
             c.CodiceCastale = reader.ReadString();
 
            c.NomeComune = reader.ReadString();
            Add(c);
        }
    }
}