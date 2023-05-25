using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab16_OOP
{
    internal class Loader
    {
        static public void Load(CycledList<Engine> list, BinaryFormatter reader, string filter)
        {
            Stream stream;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = openFileDialog.OpenFile()) != null)
                {
                    list = (CycledList<Engine>)reader.Deserialize(stream);
                    stream.Close();
                }
            }
        }
    }
}
