﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace ZeqkTools
{
    public class Functions
    {
        static public PointLatLng CalculateMiddlePoint(List<PointLatLng> points)
        {

            double lat = 0;
            double lng = 0;

            //la distancia de la latitud. la mayor latitud - la menor latitud
            double latDistance = points.Max(p => p.Lat) - points.Min(p => p.Lat);
            //la mitad de la distancia
            double auxLat = latDistance / 2;
            //calculo el punto medio entre la latitud mayor y la latitud menor
            lat = points.Min(p => p.Lat) + auxLat;

            double lngDistance = points.Max(p => p.Lng) - points.Min(p => p.Lng);
            double auxLng = lngDistance / 2;
            lng = points.Min(p => p.Lng) + auxLng;

            PointLatLng point = new PointLatLng(lat, lng);

            return point;

        }

        static public PointLatLng CalculateMiddlePoint(GMapPolygon polygon)
        {

            double lat = 0;
            double lng = 0;

            //la distancia de la latitud. la mayor latitud - la menor latitud
            double latDistance = polygon.Points.Max(p => p.Lat) - polygon.Points.Min(p => p.Lat);
            //la mitad de la distancia
            double auxLat = latDistance / 2;
            //calculo el punto medio entre la latitud mayor y la latitud menor
            lat = polygon.Points.Min(p => p.Lat) + auxLat;

            double lngDistance = polygon.Points.Max(p => p.Lng) - polygon.Points.Min(p => p.Lng);
            double auxLng = lngDistance / 2;
            lng = polygon.Points.Min(p => p.Lng) + auxLng;

            PointLatLng point = new PointLatLng(lat, lng);

            return point;

        }

        static public bool PointInPolygon(PointLatLng p, PointLatLng[] poly)
        {
            PointLatLng p1, p2;

            bool inside = false;

            if (poly.Length < 3)
            {
                return inside;
            }

            PointLatLng oldPoint = new PointLatLng(poly[poly.Length - 1].Lat, poly[poly.Length - 1].Lng);

            for (int i = 0; i < poly.Length; i++)
            {
                PointLatLng newPoint = new PointLatLng(poly[i].Lat, poly[i].Lng);
                if (newPoint.Lat > oldPoint.Lat)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.Lat < p.Lat) == (p.Lat <= oldPoint.Lat)
                    && (p.Lng - p1.Lng) * (p2.Lat - p1.Lat)
                     < (p2.Lng - p1.Lng) * (p.Lat - p1.Lat))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }

            return inside;
        }
    }
}
