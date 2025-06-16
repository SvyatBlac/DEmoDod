using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace WpfApp1
{
    public static class ConnectionDB
    {
        static string connectionLine = "Server=localhost;User=root;Password=root;Database=your_database";

        public static async Task<IEnumerable<Material>> GetMaterials()
        {
            using (var conn = new MySqlConnection(connectionLine))
            {
                await conn.OpenAsync();
                var compiler = new MySqlCompiler();
                var db = new QueryFactory(conn, compiler);

                var materials = await db.Query("materials")
                    .Join("materialtypes", "materialtypes.MaterialTypeID", "materials.MaterialTypeID")
                    .Select(
                        "materials.MaterialName AS Type",
                        "materialtypes.MaterialTypeName AS Name",
                        "materials.MinQuantity",
                        "materials.StockQuantity",
                        "materials.UnitPrice AS Price",
                        "materials.UnitOfMeasure AS Unit",
                        "materials.PackageQuantity"
                    )
                    .GetAsync<Material>();

                foreach (var material in materials)
                {
                    if (material.StockQuantity < material.MinQuantity && material.PackageQuantity > 0)
                    {
                        int deficit = material.MinQuantity - material.StockQuantity;
                        int packagesNeeded = (int)Math.Ceiling((double)deficit / material.PackageQuantity);
                        material.MinOrderCost = Math.Round(packagesNeeded * material.PackageQuantity * material.Price, 2);
                    }
                    else
                    {
                        material.MinOrderCost = 0.00m;
                    }
                }

                return materials;
            }
        }
    }
}
