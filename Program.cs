
using System;
using System.Collections.Generic;
class Program
{

    static List<List<Inputdata>> allPaths = new List<List<Inputdata>>();

    static void findPathsUtil(List<List<Inputdata>> maze,int m, int n, int i,int j, List<Inputdata> path,int index)
    {

        // If we reach the bottom of maze,
        // we can only move right
        if (i == m - 1)
        {
            for (int k = j; k < n; k++)
            {

                // path.append(maze[i][k])
                path[index + k - j] = maze[i][k];
            }

            // If we hit this block, it means one
            // path is completed. Add it to paths
            // list and print
            Console.Write("[(" + path[0].n + "," + path[0].m + "), ");
            for (int z = 1; z < path.Count - 1; z++)
            {
              //  Console.Write(path[z] + ", ");
                Console.Write("(" + path[z].n + "," + path[z].m + ") , ");
            }
            //Console.WriteLine(path[path.Count - 1] + "]");
            Console.WriteLine("(" + path[path.Count - 1].n + "," + path[path.Count - 1].m + ")]");

            allPaths.Add(path);
            return;
        }

        // If we reach to the right most
        // corner, we can only move down
        if (j == n - 1)
        {
            for (int k = i; k < m; k++)
            {
                path[index + k - i] = maze[k][j];
            }

            // path.append(maze[j][k])
            // If we hit this block, it means one
            // path is completed. Add it to paths
            // list and print
            Console.Write("[(" + path[0].n + "," + path[0].m + "), ");
            for (int z = 1; z < path.Count - 1; z++)
            {
                Console.Write("(" +path[z].n + ", " + path[z].m + "), ");
            }
            Console.WriteLine("("+ path[path.Count - 1].n +","+ path[path.Count - 1].m + ")]");
            allPaths.Add(path);
            return;
        }

        // Add current element to the path list
        //path.append(maze[i][j])
        path[index] = maze[i][j];

        // Move down in y direction and call
        // findPathsUtil recursively
        findPathsUtil(maze, m, n, i + 1,
                      j, path, index + 1);

        // Move down in y direction and
        // call findPathsUtil recursively
        findPathsUtil(maze, m, n, i, j + 1,
                            path, index + 1);
    }

    static void findPaths(List<List<Inputdata>> maze, int m, int n)
    {
        List<Inputdata> path = new List<Inputdata>();
        for (int i = 0; i < m + n - 1; i++)
        {
            path.Add(new Inputdata {m=0,n=0 });
        }
        findPathsUtil(maze, m, n, 0, 0, path, 0);
    }

    // Driver code
    static void Main()
    {
        int n = 3, m = 4;
        List<List<Inputdata>> maze = new List<List<Inputdata>>();

        for (int i = 0; i < n; i++)
        {
            List<Inputdata> inputData = new List<Inputdata>();
            for (int j = 0; j < m; j++)
            {
                Inputdata inputdata = new Inputdata();
                inputdata.m = j;
                inputdata.n = i;
                inputData.Add(inputdata);
            }
            maze.Add(inputData);
        }

        findPaths(maze, n, m);
    }

}
public class Inputdata
{
    public int m { get; set; }
    public int n { get; set; }
}