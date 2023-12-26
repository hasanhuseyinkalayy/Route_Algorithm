using System.Text;


StringBuilder input = new StringBuilder("bütünleme");
double col = 3;//matris column key
double inputLength = input.Length;
int row = (int)Math.Ceiling((double)(inputLength / col));//matris row

if (col * row > inputLength)
{
    int addLetter = (int)(col * row - inputLength);
    for (int i = 0; i < addLetter; i++)
    {
        input.Append('a');
    }
}

var encrypt = Encrypt(input);
Console.WriteLine(Encrypt(input));
Console.WriteLine(Decrypt(encrypt));
StringBuilder Encrypt(StringBuilder inputValue)
{
    StringBuilder encryptValue;
    char[,] encryptValueMatrix = new char[row, (int)col];
    int index = 0;
    for (int i = 0; i < encryptValueMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < encryptValueMatrix.GetLength(1); j++)
        {
            encryptValueMatrix[i, j] = inputValue[index++];
        }
    }
    encryptValue = RouteMatrix(encryptValueMatrix);
    return encryptValue;
}

StringBuilder Decrypt(StringBuilder encryptValue)
{
    StringBuilder decryptValue = new StringBuilder();
    char[,] decryptMatrix = DecryptRouteMatrix(encryptValue);
    for (int i = 0; i < decryptMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < decryptMatrix.GetLength(1); j++)
        {
            decryptValue.Append(decryptMatrix[i, j]);
        }
    }
    return decryptValue;
}


StringBuilder RouteMatrix(char[,] matrix)
{
    StringBuilder encryptValue = new StringBuilder();
    int top = 0;
    int bottom = matrix.GetLength(0) - 1;
    int left = 0;
    int right = matrix.GetLength(1) - 1;
    int direction = 0;
    int i;
    while (top <= bottom && left <= right)
    {
        if (direction == 0)
        {
            for (i = bottom; i >= top; i--)
            {
                encryptValue.Append(matrix[i, left]);
            }
            left++;
        }
        else if (direction == 1)
        {
            for (i = left; i <= right; i++)
            {
                encryptValue.Append(matrix[top, i]);
            }
            top++;
        }
        else if (direction == 2)
        {
            for (i = top; i <= bottom; i++)
            {
                encryptValue.Append(matrix[i, right]);

            }
            right--;
        }
        else if (direction == 3)
        {
            for (i = right; i >= left; i--)
            {
                encryptValue.Append(matrix[bottom, i]);
            }
            bottom--;
        }
        direction = (direction + 1) % 4;
    }

    return encryptValue;

}



char[,] DecryptRouteMatrix(StringBuilder encrypt)
{
    char[,] matrix = new char[row, (int)col];
    StringBuilder decryptValue = new StringBuilder();

    int top = 0;
    int bottom = matrix.GetLength(0) - 1;
    int left = 0;
    int right = matrix.GetLength(1) - 1;
    int direction = 0;
    int i;

    int index = 0;
    while (top <= bottom && left <= right)
    {
        if (direction == 0)
        {
            for (i = bottom; i >= top; i--)
            {
                matrix[i, left] = encrypt[index++];
            }
            left++;
        }
        else if (direction == 1)
        {
            for (i = left; i <= right; i++)
            {
                matrix[top, i] = encrypt[index++];
            }
            top++;
        }
        else if (direction == 2)
        {
            for (i = top; i <= bottom; i++)
            {
                matrix[i, right] = encrypt[index++];
            }
            right--;
        }
        else if (direction == 3)
        {
            for (i = right; i >= left; i--)
            {
                matrix[bottom, i] = encrypt[index++];
            }
            bottom--;
        }
        direction = (direction + 1) % 4;
    }
    return matrix;
}
