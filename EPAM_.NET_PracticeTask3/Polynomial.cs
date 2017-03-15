using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_.NET_PracticeTask3
{
    class Polynomial
    {
        int power;
        double[] arrayCoeff;

        private Polynomial(int power)
        {
            if (power<0)
            {
                throw new Exception("power must be zero or more than zero ");
            }
            this.power = power;
            this.arrayCoeff = new double[power + 1];
        }
        public Polynomial(int power, IEnumerable<double> collection)
        {
            if (collection.Count() != power+1)
            {
                throw new Exception("Incorrect size of array with indexes of polynomial");
            }
            this.power = power;
            this.arrayCoeff = new double[power + 1];
            for (int i = 0; i < collection.Count(); i++)
            {
                this.arrayCoeff[i] = collection.ElementAt(i);
            }         
        }
        public double CalculateValue(double x)
        {
            double result = 0;
            for (int i = 0; i < arrayCoeff.Count(); i++)
            {
                result += arrayCoeff[i] * Math.Pow(x, i);
            }
            return result;
        }
        public Polynomial AddPolynomial(Polynomial polynomToAdd)
        {
            if (this.arrayCoeff.Count() > polynomToAdd.arrayCoeff.Count())
            {
                Polynomial resPolynom = new Polynomial(this.power);
                for (int i = this.arrayCoeff.Count() - 1; i >= polynomToAdd.arrayCoeff.Count(); i--)
                {
                    resPolynom.arrayCoeff[i] = this.arrayCoeff[i];
                }
                for (int i = 0; i < polynomToAdd.arrayCoeff.Count(); i++)
                {
                   resPolynom.arrayCoeff[i] = this.arrayCoeff[i] + polynomToAdd.arrayCoeff[i];
                }
                return resPolynom;
            }
            else
            {
                Polynomial sumPolynom = new Polynomial(polynomToAdd.arrayCoeff.Count() - 1);
                for (int i = 0; i < this.arrayCoeff.Count(); i++)
                {
                    sumPolynom.arrayCoeff[i] = this.arrayCoeff[i] + polynomToAdd.arrayCoeff[i];
                }
                for (int i = this.arrayCoeff.Count(); i < polynomToAdd.arrayCoeff.Count(); i++)
                {
                    sumPolynom.arrayCoeff[i] = polynomToAdd.arrayCoeff[i];
                }
                return sumPolynom;
            }
        }

        public Polynomial SubtractPolynomial(Polynomial polynomToMinus)
        {
            if (this.arrayCoeff.Count() > polynomToMinus.arrayCoeff.Count())
            {
                Polynomial resPolynom = new Polynomial(this.power);
                for (int i = this.arrayCoeff.Count() - 1; i >= polynomToMinus.arrayCoeff.Count(); i--)
                {
                    resPolynom.arrayCoeff[i] = this.arrayCoeff[i];
                }
                for (int i = 0; i <polynomToMinus.arrayCoeff.Count(); i++)
                {
                    resPolynom.arrayCoeff[i] = this.arrayCoeff[i] - polynomToMinus.arrayCoeff[i];
                }
                return resPolynom;
            }
            else
            {
                Polynomial sumPolynom = new Polynomial(polynomToMinus.arrayCoeff.Count() - 1);
                for (int i = 0; i < this.arrayCoeff.Count(); i++)
                {
                    sumPolynom.arrayCoeff[i] = this.arrayCoeff[i] - polynomToMinus.arrayCoeff[i];
                }
                for (int i = this.arrayCoeff.Count(); i < polynomToMinus.arrayCoeff.Count(); i++)
                {
                    sumPolynom.arrayCoeff[i] = - polynomToMinus.arrayCoeff[i];
                }
                return sumPolynom;
            }
        }
        public Polynomial MultiplyByPolynomial(Polynomial polynomToMultiply)
        {
            int powerResPolynom = this.arrayCoeff.Count() + polynomToMultiply.arrayCoeff.Count() - 2;
            Polynomial resultPolynom = new Polynomial(powerResPolynom);
            for(int i=0;i< this.arrayCoeff.Count();i++)
            {
                for (int j = 0; j < polynomToMultiply.arrayCoeff.Count(); j++)
                {
                    resultPolynom.arrayCoeff[i + j] += this.arrayCoeff[i] * polynomToMultiply.arrayCoeff[j];
                }
            }

            return resultPolynom;
        }
        public override string ToString()
        {
            String strPolynom = "";
            for (int i = this.arrayCoeff.Count()-1; i >=0; i--)
            {
                strPolynom += this.arrayCoeff[i] + "*x^" + i;
                if (i!=0)
                {
                    strPolynom += " + ";
                }
            }
            return strPolynom;
        }
    }
}
