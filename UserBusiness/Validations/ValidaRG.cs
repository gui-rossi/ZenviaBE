﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusiness.Validations
{
    public static class ValidaRG
    {
        public static bool isRg(string rg)
        {
            //Elimina da string os traços, pontos e virgulas,
            rg = rg.Replace("-", "").Replace(".", "").Replace(",", "");

            //Verifica se o tamanho da string é 9
            if (rg.Length == 9)
            {
                int[] n = new int[9];

                try
                {
                    n[0] = Convert.ToInt32(rg.Substring(0, 1));
                    n[1] = Convert.ToInt32(rg.Substring(1, 1));
                    n[2] = Convert.ToInt32(rg.Substring(2, 1));
                    n[3] = Convert.ToInt32(rg.Substring(3, 1));
                    n[4] = Convert.ToInt32(rg.Substring(4, 1));
                    n[5] = Convert.ToInt32(rg.Substring(5, 1));
                    n[6] = Convert.ToInt32(rg.Substring(6, 1));
                    n[7] = Convert.ToInt32(rg.Substring(7, 1));
                    if (rg.Substring(8, 1).Equals("x") || rg.Substring(8, 1).Equals("X"))
                    {
                        n[8] = 10;
                    }
                    else
                    {
                        n[8] = Convert.ToInt32(rg.Substring(8, 1));
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                //obtém cada um dos caracteres do rg

                //Aplica a regra de validação do RG, multiplicando cada digito por valores pré-determinados
                n[0] *= 2;
                n[1] *= 3;
                n[2] *= 4;
                n[3] *= 5;
                n[4] *= 6;
                n[5] *= 7;
                n[6] *= 8;
                n[7] *= 9;
                n[8] *= 100;

                //Valida o RG
                int somaFinal = n[0] + n[1] + n[2] + n[3] + n[4] + n[5] + n[6] + n[7] + n[8];
                if ((somaFinal % 11) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
