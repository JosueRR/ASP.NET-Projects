namespace LabCleanCode
{
    public class BosqueEncantado
    {
        private int[,] matrizBosque;
        private int cantidadFilas;
        private int cantidadColumnas;
        //LAGO ENCANTADO: 1
        //ARBOL: 2
        //VACIO: 3

        public BosqueEncantado(int pfilas, int pcolumnas)
        {
            cantidadFilas = pfilas;
            cantidadColumnas = pcolumnas;
            matrizBosque = new int[cantidadFilas, cantidadColumnas];
            double doubleAleatorio;
            int int_decision;
            for (int f = 0; f < cantidadFilas; ++f)
            {
                for (int c = 0; c < cantidadColumnas; ++c)
                {
                    doubleAleatorio = (Math.random() * 3) + 1;
                    int_decision = (int)numeroAleatorio;
                    if (int_desicion == 1)
                    {
                        matrizBosque[f,c] = 1;
                    }
                    if (int_decision == 2)
                    {
                        matrizBosque[f,c] = 2;
                    }

                    if (int_decision == 3)
                    {
                        matrizBosque[f,c] = 3;
                    }
                    if (int_decision != 3 && int_decision != 2 && int_decision != 1)
                    {
                        doubleAleatorio = (Math.random() * 3) + 1;
                    }
                }
            }
        }


        public int num_lag_vec(int pf, int pc, int pIntCont, var matriz)
        {
            for (int estaFila = pf - 1; estaFila <= pf + 1; ++estaFila)
            {
                for (int estaColumna = pc - 1; estaColumna <= pc + 1; ++estaColumna)
                {
                    if (!(estaFila == pf && estaColumna == pc))
                    {
                        if (0 <= estaFila && 0 <= estaColumna && pf < cantidadFilas && pc < cantidadColumnas)
                        {
                            if (matriz[pf,pc] == 1)
                                ++pIntCont;
                        }
                    }
                }
            }
            return pIntCont;
        }

        public int num_arb_vec(int pf, int pc, int pIntCont, var pmatriz)
        {
            for (int estaFila = pf - 1; estaFila <= pf + 1; ++estaFila)
            {
                for (int estaColumna = pc - 1; estaColumna <= pc + 1; ++estaColumna)
                {
                    if (!(estaFila == pf && estaColumna == pc))
                    {
                        if (0 <= estaFila && 0 <= estaColumna && pf < cantidadFilas && pc < cantidadColumnas)
                        {
                            if (pmatriz[pf,pc] == 2)
                                ++pIntCont;
                        }
                    }
                }
            }
            return pIntCont;
        }

        public void cambiarnumerosdelbosque()
        {
            for (int f = 0; f < cantidadFilas; ++f)
            {
                for (int c = 0; c < cantidadColumnas; ++c)
                {
                    int contadorArboles = num_arb_vec(f,c,0,matrizBosque);
                    int contadorLagos = num_lag_vec(f,c,0,matrizBosque);
                    if (matrizBosque[f,c] == 2)
                    {
                        if (contadorLagos >= 4)
                        {
                            matrizBosque[f,c] = 1;
                        }
                        else
                        {
                            if (contadorArboles > 4)
                            {
                                matrizBosque[f,c] = 2;
                            }
                        }
                    }
                    if (matrizBosque[f,c] == 1)
                    {
                        if (contadorLagos < 3)
                            matrizBosque[f,c] = 3;
                    }

                    if (matrizBosque[f,c] == 3)
                    {
                        if (contadorArboles >= 3)
                            matrizBosque[f,c] = 2;
                    }
                }
            }
			Pantalla p = new Pantalla(matrizBosque);
			string s=p.crear();
			//imp pantalla
        }
    }
}