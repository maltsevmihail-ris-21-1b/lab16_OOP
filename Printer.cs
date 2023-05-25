using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace lab16_OOP
{
    internal class Printer
    {
        public Printer() { }

        static public void Save(CycledList<Engine> list, BinaryFormatter printer, string filter)
        {
            Stream stream;
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    printer.Serialize(stream, list);
                    stream.Close();
                }
            }
        }
    }
}
