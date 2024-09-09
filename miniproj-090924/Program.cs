Random rand = new Random();

static bool DoesExist(int[,] mat)
{
    if (mat != null && mat.Length > 0)
        return true;
    return false;
}

int SaisieNombre()
{
    int n;
    Console.WriteLine("Ce nombre doit être positif");
    while (!Int32.TryParse(Console.ReadLine(), out n) || n <= 0)
    {
        Console.WriteLine("Should be positive integer");
        
    }

    return n;
}

int[,] InitMatrice(int ligne, int colonne)
{
    int[,] matrice = new int[ligne, colonne];
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
                if (mat[i, j] < 10) Console.Write("0");
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


static int NbValeursSup7(int[,] mat, int i0, int j0)
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
    
    //Retourner le nombre de case autour avec une valeur de 7 ou +
    return n;
}

static bool[,] CorrectionMatrice(int[,] mat)
{
    //pas besoin de retourné un tableau car la valeur de la memoir est renvoyer
    
    //crée une seconde matrice pour pouvoir modifier sans "endomager" la matrice initiale.
    int[,] matCorriger = new int[mat.GetLength(0),mat.GetLength(1)];
    bool[,] matCorrigerBools = new bool[mat.GetLength(0),mat.GetLength(1)];
    // pas besoin de copier la matrice car, les valeurs égale à 0 suffise car nous ne regarderons pas la valeur
    // contenu de la matrice

    //parcourir l'ensemble de la matrice
    for (int i = 0; i < mat.GetLength(0); i++)
    {
        for (int j = 0; j < mat.GetLength(1); j++)
        {
            //récupéré la valeur de mat
            int newValue = mat[i, j];
            
            //récupéré le nombre de voisin
            int nbVoisinSup7 = NbValeursSup7(mat, i, j);
            
            //si c'est 2 ou 3
            if (nbVoisinSup7 < 4 && nbVoisinSup7 > 1)
            {
                //déviser par deux sa valeur
                newValue /= 2;
            }
            //si c'est inf à 4 mettre à 0 (continue) sinon ne rien faire et passer à la suite des executions.
            else if(nbVoisinSup7 < 2) continue;

            matCorriger[i, j] = newValue;
            matCorrigerBools[i, j] = true;
        }
    }
    
    //remplacer la matrice initiale par la matrice corrigé
    for(int i = 0; i < mat.GetLength(0); i++)
    {
        for(int j = 0; j < mat.GetLength(1); j++)
        {
            mat[i, j] = matCorriger[i, j];
        }
    }
    //vue que c'est un emplacement mémoire, pas besoin de retourne de matrice seulement
    //la matrice avec les emplacement modifier.
    return matCorrigerBools;
}

// main
int i = 1;
int nbIterations;
Console.WriteLine("Entrez le nombre de lignes de la matrice");
int ligne = SaisieNombre();
Console.WriteLine("Entrez le nombre de colonnes de la matrice");
int colonne = SaisieNombre();

int[,] matrice = InitMatrice(ligne, colonne);

Console.WriteLine("Combien de fois voulez-vous tenter de corriger la matrice ?");
Console.WriteLine($"Pour une petite (< à 10*10) matrice 1 ou 2, une moyenne (< 50*50) 3 à 5, et plus à vous de voir !");
nbIterations = SaisieNombre();

Console.WriteLine("Voici votre matrice de début :\n");
Affichage(matrice);

while (i <= nbIterations)
{
    Console.WriteLine($"C'est votre {i}e itération");
    // insérer fonction correction calcul
    CorrectionMatrice(matrice);
    // petite animation pour le calcul ?

    Console.WriteLine("Voici votre matrice corrigée :\n");
    Affichage(matrice); // à voir si tu veux modifier le nom du tableau
    Console.WriteLine("\nAppuyez sur une touche pour afficher une nouvelle itération\n\n\n");
    Console.ReadKey();
    i++;
}

System.Environment.Exit(0);
