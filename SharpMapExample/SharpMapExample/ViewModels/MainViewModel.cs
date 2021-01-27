/**********************************************************************
** Copyright © 2020 广州南方智能技术有限公司 All rights reserved.
***********************************************************************
** CLR 版本:4.0.30319.42000
** 创建时间:2020/10/16 14:34:29
** 作    者:GuoYingdong
** 说    明:
** ============================== 修改 ============================== **
** 修改时间:
** 作    者:
** 说    明:
**********************************************************************/
using GeoAPI.Geometries;
using SharpMap;
using SharpMap.Forms;
using SharpMap.Layers;
using SharpMapExample.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SharpMapExample.ViewModels
{
    public class MainViewModel : NotifyPropertyBase
    {
        public MainViewModel(MapBox mapBox)
        {
            MapBox = mapBox;
            Map = mapBox.Map;

            Layers.CollectionChanged += LayersChange;

        }
        public static MapBox MapBox { get; set; }
        public static Map Map { get; set; }
        private ObservableCollection<ILayer> layers = new ObservableCollection<ILayer>();
        public ObservableCollection<ILayer> Layers
        {
            get => layers;
            set
            {
                layers = value;
            }
        }

        #region Command
        public BaseCommand AddLayerCommand => new BaseCommand(() =>
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = @"Shapefiles (*.shp)|*.shp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ds = new SharpMap.Data.Providers.ShapeFile(ofd.FileName);
                var lay = new SharpMap.Layers.VectorLayer(System.IO.Path.GetFileNameWithoutExtension(ofd.FileName), ds);
                if (ds.CoordinateSystem != null)
                {
                    GeoAPI.CoordinateSystems.Transformations.ICoordinateTransformationFactory fact =
                        new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();

                    lay.CoordinateTransformation = fact.CreateFromCoordinateSystems(ds.CoordinateSystem,
                        ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator);
                    lay.ReverseCoordinateTransformation = fact.CreateFromCoordinateSystems(ProjNet.CoordinateSystems.ProjectedCoordinateSystem.WebMercator,
                        ds.CoordinateSystem);
                }
                Map.Layers.Add(lay);
                Layers = new ObservableCollection<ILayer>();
                Map.Layers.ToList().ForEach(p => Layers.Add(p));
                if (Map.Layers.Count == 1)
                {
                    Envelope env = lay.Envelope;
                    Map.ZoomToBox(env);
                }
                MapBox.Refresh();
                OnPropertyChanged(nameof(Layers));
            }
        });
        #endregion

        #region methods
        public void LayersChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            Layers.ToList().ForEach(p =>
            {
                if (Map.Layers.FirstOrDefault(a => a == p) == null)
                {
                    Map.Layers.Add(p);
                }
            });
        }

        public void SelectFeature(MouseEventArgs e)
        {

        }
        #endregion
    }
}
