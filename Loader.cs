using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab16_OOP
{
    internal class Loader
    {
        static public CycledList<Engine> BinaryLoad(CycledList<Engine> list, BinaryFormatter reader, string filter)
        {
            CycledList<Engine> newEngines = new CycledList<Engine>();
            Stream stream;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    newEngines = (CycledList<Engine>)reader.Deserialize(stream);
                    stream.Close();
                }
            }
            return newEngines;
        }
        static public CycledList<Engine> JsonLoad(CycledList<Engine> list, string filter)
        {
            CycledList<Engine>? newEngines = new CycledList<Engine>();
            Stream stream;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    newEngines = JsonSerializer.Deserialize<CycledList<Engine>>(stream);
                    stream.Close();
                }
            }
            return newEngines;
        }
        static public CycledList<Engine> XmlLoad(CycledList<Engine> list, string filter)
        {
            CycledList<Engine> newEngines = new CycledList<Engine>();
            Stream stream;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;

            var serializer = new XmlSerializer(typeof(CycledList<Engine>));

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    newEngines = (CycledList<Engine>)serializer.Deserialize(stream);
                    stream.Close();
                }
            }
            return newEngines;
        }
    }
}
