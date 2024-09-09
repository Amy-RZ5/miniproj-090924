Random rand = new Random();

bool DoesExist(int[,] mat)
{
    if (mat != null && mat.Length > 0)
        return true;
    return false;
}

int[,] InitMatrice(int ligne, int colonne)
{
    int[,] matrice = new int[3, 3];
    for (int i = 0; i < ligne; i++)
    {
        for (int j = 0; j < colonne; j++)
        {
            matrice[i, j] = rand.Next(1, 15);
        }
    }

    return matrice;
}

void Affichage(int[,] mat)
{
    if (DoesExist(mat))
    {
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

int[,] Copy(int[,] matCorr, int[,] matInit)
{
    int[,] result = null;
    if (DoesExist(matCorr)&& DoesExist(matInit))
    {
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++) matInit[i, j] = matCorr[i, j];
        }
    }
    return matInit;
}

int NbValeursSup7(int[,] mat, int i0, int j0)
{
    //verifier que la matrice existe et est correcte
    if (!DoesExist(mat)) return -1;
    
    //n correspond au nombre de valeurs voisine supérieures à 7
    int n = 0;
    
    //On parcours l'ensemble de la matrice.
    for (int i = i0 - 1; i <= i0 + 1; i++)
    {
        for (int j = j0 - 1; j <= j0 + 1; j++)
        {
            //Verficication que la case du tableau est bien dans la matrice
            if (i < 0 || j < 0 || i >= mat.GetLength(0) || j >= mat.GetLength(1) || (i == i0 && j == j0)) continue;
            
            //Si la case qui est verifier à une valeur supperieur à 7, rajouter 1 au compteur.
            if (mat[i, j] >= 7) n++;
        }
    }
    
    //Netourner le nombre de case au tour avec une valeur de 7 ou +
    return n;
}

