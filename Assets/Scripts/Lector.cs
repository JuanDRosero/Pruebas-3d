using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class Lector 
{
    public static string getTitulo(string ruta)
    {
        
        try
        {
            StreamReader st = new StreamReader(ruta);
            return st.ReadLine();
            st.Close();
        }
        catch(Exception e)
        {
            return "Error: "+e.Message;
        }

    }
    public static string getDesc(string ruta)
    {
        String linea="";
        try
        {
            StreamReader st = new StreamReader(ruta);
            for (int i = 0; i < 2; i++)
            {
                linea = st.ReadLine();
            }
            return linea;
            st.Close();
        }
        catch (Exception e)
        {
            return "Error: "+e.Message;
        }

    }

}
