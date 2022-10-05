﻿using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        
        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Renk Eklendi");
        }

        public void Delete(int id)
        {
            var color = _colorDal.Get(co => co.ColorId == id);
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetById(int colorId)
        {
            return _colorDal.GetAll(co => co.ColorId == colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Renk Güncellendi");
        }
    }
}