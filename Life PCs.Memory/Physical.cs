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
        /// <returns>Колекция локальных дисков</returns>
        public ObservableCollection<Disk> Refresh()
        {
            disks = new ObservableCollection<Disk>();
            driveInfo = DriveInfo.GetDrives();

            foreach (DriveInfo drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    double TotalOccupiedSpace = (drive.TotalSize - drive.TotalFreeSpace) / 1024.0 / 1024.0 / 1024.0;
                    double TotalSize = drive.TotalSize / 1024.0 / 1024.0 / 1024.0;
                    int Percent = (int)((drive.TotalSize - drive.TotalFreeSpace) * 100 / drive.TotalSize);
                    disks.Add(new Disk(drive.Name, TotalOccupiedSpace, Percent, TotalSize));
                }
                else
                    continue;
            }

            return disks;
        }
        #endregion
    }
}