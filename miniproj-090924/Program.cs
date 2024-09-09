// See https://aka.ms/new-console-template for more information

Random rand = new Random();

bool DoesExist(int[,] mat)
{
    if (mat != null && mat.Length > 0)
        return true;
    return false;
}

int SaisieNombre()
{
    int n;
    while (Int32.TryParse(Console.ReadLine(), out n) || n <= 0)
    {
        Console.WriteLine("should be positive integer");
        
    }

    return n;
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
    int n = 0;
    if (DoesExist(mat))
    {
        for (int i = i0 - 1; i <= i0 + 1; i++)
        {
            for (int j = j0 - 1; j <= j0 + 1; j++)
            {
                if (i == i0 && j == j0)
                    j++;
                if (mat[i, j] >= 7) n++;
            }
        }
    }

    return n;
}


// main
int i = 1;
int nbIterations = 0;


