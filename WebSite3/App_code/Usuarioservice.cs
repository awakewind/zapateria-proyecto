using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapateria_clases;

/// <summary>
/// Descripción breve de Usuarioservice
/// </summary>
public interface  Usuarioservice
{
    
        int add(usuarios   usuario  );
        int update(usuarios   usuario  );
        int remove(usuarios   usuario  );

        usuarios  findById(Int32 id_usuario);
        usuarios  login(usuarios  usuario);

    List<usuarios > findAll();
    
}