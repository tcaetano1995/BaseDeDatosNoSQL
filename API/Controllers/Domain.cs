using System;
using System.Collections.Generic;

// Domain model for messages grouped by foro and date
public class MessagesByForo
{
    public Guid ForoId { get; set; }
    public DateTime Date { get; set; }
    public Guid MessageId { get; set; }
    public Guid TopicId { get; set; }
    public string TopicName { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    public List<string> Links { get; set; }
    public List<string> Hashtags { get; set; }
}

// Domain model for messages grouped by topic and date
public class MessagesByTopic
{
    public Guid TopicId { get; set; }
    public DateTime Date { get; set; }
    public Guid MessageId { get; set; }
    public Guid ForoId { get; set; }
    public string ForoName { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    public List<string> Links { get; set; }
    public List<string> Hashtags { get; set; }
}

// Domain model for messages indexed by message_id
public class MessageById
{
    public Guid MessageId { get; set; }
    public DateTime Date { get; set; }
    public Guid TopicId { get; set; }
    public Guid ForoId { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    public List<string> Links { get; set; }
    public List<string> Hashtags { get; set; }
}


public class Juego
{
    public Guid IdJuego { get; set; }
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public string Desarrollador { get; set; }
    public DateTime FechaLanzamiento { get; set; }
}

public class Usuario
{
    public Guid IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }
}

public class Actividad
{
    public Guid IdUsuario { get; set; }
    public Guid IdJuego { get; set; }
    public int HorasJugadas { get; set; }
    public List<string> Logros { get; set; }
    public List<string> NivelesDesbloqueados { get; set; }
    public DateTime FechaUltimaSesion { get; set; }
}