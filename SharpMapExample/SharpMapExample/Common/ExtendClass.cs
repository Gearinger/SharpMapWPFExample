/**********************************************************************
** Copyright © 2020 广州南方智能技术有限公司 All rights reserved.
***********************************************************************
** CLR 版本:4.0.30319.42000
** 创建时间:2020/10/16 15:34:43
** 作    者:GuoYingdong
** 说    明:
** ============================== 修改 ============================== **
** 修改时间:
** 作    者:
** 说    明:
**********************************************************************/
using SharpMap.Layers;
using SharpMapExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMapExample.Common
{
    public static class ExtendClass
    {
        public static void Add2(this LayerCollection layerCollection, ILayer layer)
        {
            layerCollection.Add(layer);
            MainViewModel.Layers = new System.Collections.ObjectModel.ObservableCollection<Layer>();
            layerCollection.ToList().ForEach(p=> MainViewModel.Layers.Add(p as Layer));
        }
    }
}
