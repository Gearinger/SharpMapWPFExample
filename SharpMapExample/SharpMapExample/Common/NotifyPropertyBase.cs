/**********************************************************************
** Copyright © 2020 广州南方智能技术有限公司 All rights reserved.
***********************************************************************
** CLR 版本:4.0.30319.42000
** 创建时间:2020/10/16 14:32:10
** 作    者:GuoYingdong
** 说    明:
** ============================== 修改 ============================== **
** 修改时间:
** 作    者:
** 说    明:
**********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpMapExample.Common
{
    /// <summary>
    /// 实现INotifyPropertyChanged接口
    /// </summary>
    public class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
