/**********************************************************************
** Copyright © 2020 广州南方智能技术有限公司 All rights reserved.
***********************************************************************
** CLR 版本:4.0.30319.42000
** 创建时间:2020/10/16 21:37:46
** 作    者:GuoYingdong
** 说    明:
** ============================== 修改 ============================== **
** 修改时间:
** 作    者:
** 说    明:
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpMap.Layers;
using SharpMapExample.Common;

namespace SharpMapExample.Models
{
    public class Layer:NotifyPropertyBase
    {
        private string name;

        public string Name { get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
            }
    }
}
