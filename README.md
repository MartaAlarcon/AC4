# AC4

## IA

### haz la query para este metodo  : DeleteComarca(int CodiComarca)
```
DELETE FROM NombreTablaComarcas
WHERE CodiComarca = @CodiComarca;
````
### adáptalo para usarlo en c#
```
using System.Data.SqlClient;

public void DeleteComarca(int CodiComarca)
{
    // Cadena de conexión a la base de datos
    string connectionString = "cadena_de_conexion";

    // Consulta SQL con parámetro
    string queryString = "DELETE FROM NombreTablaComarcas WHERE CodiComarca = @CodiComarca";

    // Crear y abrir conexión
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        
        // Agregar parámetro
        command.Parameters.AddWithValue("@CodiComarca", CodiComarca);

        // Abrir conexión y ejecutar la consulta
        connection.Open();
        command.ExecuteNonQuery();
    }
}
```
### crea un clase ComarcaDTO con los siguientes atributos publicos: Year,Codi comarca,Comarca,Població,Domèstic xarxa,Activitats econòmiques i fonts pròpies,Total,Consum domèstic per càpita
```
public class ComarcaDTO
{
    public int Year { get; set; }
    public int CodiComarca { get; set; }
    public string Comarca { get; set; }
    public int Població { get; set; }
    public int DomèsticXarxa { get; set; }
    public int ActivitatsEconòmiques { get; set; }
    public int Total { get; set; }
    public int ConsumDomèsticPerCàpita { get; set; }
}
```

## Webgrafia

Npgsql. (s. f.). GitHub - npgsql/npgsql: Npgsql is the .NET data provider for PostgreSQL. GitHub. https://github.com/npgsql/npgsql

Store and read connection string in appsettings.json - ConnectionStrings.com. (s. f.). https://www.connectionstrings.com/store-and-read-connection-string-in-appsettings-json/
