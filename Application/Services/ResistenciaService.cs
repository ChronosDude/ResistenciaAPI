using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Application.Services
{

    public class ResistenciaService
    {
        public string Calcular(Resistencia res)
        {
           //Dejamos a minuscula los textos para evitar problemas con la escritura e inicializamos valores
           
            var _color1 = res.Color1.ToLower();
            var _color2 = res.Color2.ToLower();
            var _color3 = res.Color3.ToLower();
            var _color4 = res.Color4.ToLower();


            int val1;
            int val2;
            int val3;
            int val4;

            //asignamos el valor segun los colores para as bandas, en caso de que no coincida con ninguno, retornamos un mensaje avisando al usuario
            switch (_color1)
            {
                case "negro": val1 = 0; break;
                case "cafe": val1 = 10; break;
                case "rojo": val1 = 20; break;
                case "naranja": val1 = 30; break;
                case "amarillo": val1 = 40; break;
                case "verde": val1 = 50; break;
                case "azul": val1 = 60; break;
                case "violeta": val1 = 70; break;
                case "gris": val1 = 80; break;
                case "blanco": val1 = 90; break;
                case null: return ("No se recibio el PRIMER color");
                default: return ("PRIMER color invalido");

            }

            switch (_color2)
            {
                case "negro": val2 = 0; break;
                case "cafe": val2 = 1; break;
                case "rojo": val2 = 2; break;
                case "naranja": val2 = 3; break;
                case "amarillo": val2 = 4; break;
                case "verde": val2 = 5; break;
                case "azul": val2 = 6; break;
                case "violeta": val2 = 7; break;
                case "gris": val2 = 8; break;
                case "blanco": val2 = 9; break;
                case null: return ("No se recibio el SEGUNDO color");
                default: return ("SEGUNDO color invalido");

            }
             
             //condicion cuando una resistencia tiene el valor de 0
             if(val1 ==0&&val2==0)
             {
                 return("Tu resistencia no resiste nada XD, intenta cambiar el primer o segundo color");
             }

            switch (_color3)
            {
                case "negro": val3 = 1; break;
                case "cafe": val3 = 10; break;
                case "rojo": val3 = 100; break;
                case "naranja": val3 = 1000; break;
                case "amarillo": val3 = 10000; break;
                case "verde": val3 = 100000; break;
                case "azul": val3 = 1000000; break;
                case null: return ("No se recibio el TERCER color");
                default: return ("TERCER color invalido");

            }

            switch (_color4)
            {
                case "dorado": val4 = 5; break;
                case "plata": val4 = 10; break;
                case null: return ("No se recibio el primer color");
                default: return ("CUARTO color invalido solo se acepta  DORADO y PLATA");

            }


            //operaciones para calular el valor de la resistencia, asi como su tolerancia y su resistencia minima y maxima.
            double resis = (val1+val2)*val3;
            double tol = (val4*resis)/100;
            double resismin = resis - tol;
            double resismax = resis + tol;

            return ($"La resistencia es de {resis} Ω. Con una tolerancia de {tol} Ω. Minimo de {resismin} Ω y máximo de {resismax} Ω");
        }
    }
}
