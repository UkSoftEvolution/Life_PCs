using System;
using System.Management;

namespace Life_PCs.CPU
{
    /// <summary>
    /// Класс с методами для работы с CPU компьютера
    /// </summary>
    public class Processor
    {
        #region Methods
        /// <summary>
        /// Метод для определения нагрузки CPU
        /// </summary>
        /// <returns>item1: Имя процессора, item2: Загруженность процессора</returns>
        public (string, int) Refresh()
        {
            var managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            var Get = managementObjectSearcher.Get();
            var GetEnumerator = Get.GetEnumerator();
            GetEnumerator.MoveNext();
            var managementObject = (ManagementObject)GetEnumerator.Current;
            return (managementObject["Name"].ToString(), Convert.ToInt16(managementObject["LoadPercentage"]));
        }
        #endregion
    }
}