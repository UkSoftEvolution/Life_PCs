using System.Collections.ObjectModel;
using System.IO;

namespace Life_PCs.Memory
{
    /// <summary>
    /// Класс с методами для работы с SSD и HDD устройствами компьютера
    /// </summary>
    public class Phisical
    {
        #region Fields
        private ObservableCollection<Disk> disks; //Коллекция локальных дисков
        private DriveInfo[] driveInfo; //Массив с информациях о дисках
        #endregion

        #region Function
        /// <summary>
        /// Метод для обновления данных о SSD и HDD устройствах на компьютере
        /// </summary>
        /// <returns>Колекция локальных дисков, Всего занято памяти, Всего памяти, Проценты занятой памяти</returns>
        public (ObservableCollection<Disk>, double, double, int) Refresh()
        {
            disks = new ObservableCollection<Disk>();
            driveInfo = DriveInfo.GetDrives();

            long AllOccupied = 0; //Всего занято памяти в байтах
            long AllTotal = 0; //Всего памяти в байтах

            foreach (DriveInfo drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    AllOccupied += drive.TotalSize - drive.TotalFreeSpace;
                    AllTotal += drive.TotalSize;

                    int Percent = (int)((drive.TotalSize - drive.TotalFreeSpace) * 100 / drive.TotalSize);
                    disks.Add(new Disk(drive.Name, ConvertToGB((drive.TotalSize - drive.TotalFreeSpace)), Percent, ConvertToGB(drive.TotalSize)));
                }
                else
                    continue;
            }

            int AllPercent = (int)(AllOccupied * 100 / AllTotal);

            return (disks, ConvertToGB(AllOccupied), ConvertToGB(AllTotal), AllPercent);
        }
        /// <summary>
        /// Функция для конвертирования байтов в гигабайты
        /// </summary>
        /// <param name="ConvertValue">Значение которое нужно конвертировать</param>
        /// <returns>Значение в гигабайтах</returns>
        private double ConvertToGB(long ConvertValue) => ConvertValue / 1024.0 / 1024.0 / 1024.0;
        #endregion
    }
}