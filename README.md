# Proyecto Base de datos no relacionales

Equipo integrado por: 

Mateo Gauthier – N° Estudiante: 217385
Tomas caetano –  Nº Estudiante: 189213
Marcelo Macedo – N° Estudiante: 223114 

## Descripción

Este proyecto tiene como objetivo la utilización de Cassandra con C#.

## Requisitos

- Docker Desktop (4.30.0 - en nuestro caso).
- Git.
- Visual Studio (2022 - en nuestro caso).

Nota: (Utilizamos .net 6 con c#)


## Instalación

Sigue estos pasos para configurar el proyecto en tu máquina local.

### Paso 1: Clonar el repositorio

```bash
git clone https://github.com/tcaetano1995/BaseDeDatosNoSQL.git
cd BaseDeDatosNoSQL

### Paso 2: Correr el docker

docker run --name my-cassandra-db -p 9042:9042 -p 7000:7000 -d cassandra:latest

docker exec -it  my-cassandra-db cqlsh


### Paso 3: Crear la estructura en cassandra para la Parte 4

CREATE KEYSPACE obligatorio WITH replication = {'class': 'SimpleStrategy', 'replication_factor' : 1};

USE obligatorio;


CREATE TABLE IF NOT EXISTS juegos (
    id_juego UUID PRIMARY KEY,
    nombre TEXT,
    genero TEXT,
    desarrollador TEXT,
    fecha_lanzamiento DATE
);


CREATE TABLE IF NOT EXISTS usuarios (
    id_usuario UUID PRIMARY KEY,
    nombre TEXT,
    email TEXT,
    fecha_registro TIMESTAMP
);


CREATE TABLE IF NOT EXISTS actividad (
    id_usuario UUID,
    id_juego UUID,
    horas_jugadas INT,
    logros list<TEXT>,
    niveles_desbloqueados list<TEXT>,
    fecha_ultima_sesion TIMESTAMP,
    PRIMARY KEY ((id_usuario), id_juego, fecha_ultima_sesion)
) WITH CLUSTERING ORDER BY (id_juego ASC, fecha_ultima_sesion DESC);

### Paso 4: Insertar datos de prueba

  Encontrara dentro de la carpeta descargada del repo un archivo datosDePruebaSec4.txt
  Ejecute el mismo dentro de Cassandra.

### Paso 5: Cree ka estructura de Cassandra para la parte 5

  CREATE TABLE messages_by_foro (
    foro_id UUID,
    date date,
    message_id timeuuid,
    topic_id UUID,
    topic_name text,
    user_name text,
    texto text,
    links list<text>,
    hashtags list<text>,
    PRIMARY KEY ((foro_id, date), message_id)
) WITH CLUSTERING ORDER BY (message_id DESC);


CREATE TABLE messages_by_topic (
    topic_id uuid, 
    date date, 
    message_id timeuuid,
    foro_id uuid, 
    foro_name text,  
    user_name text, 
    texto text, 
    links list<text>, 
    hashtags list<text>, 
    PRIMARY KEY ((topic_id, date), message_id)
) WITH CLUSTERING ORDER BY (message_id DESC);


CREATE TABLE messages_by_id (
    message_id timeuuid PRIMARY KEY, 
    date date, 
    topic_id uuid, 
    foro_id uuid, 
    user_name text, 
    texto text, 
    links list<text>, 
    hashtags list<text>
);

### Paso 6: Inserte los datos de prueba para la parte 5

 Encontrara dentro de la carpeta descargada del repo un archivo datosDePruebaSec5.txt
  Ejecute el mismo dentro de Cassandra.


### Paso 7: Ejecutar en visual studio

  Encontraremos una Carpeta API, la cual procederemos a abrir con .net6, no es necesario configurar nada, simplemente al darle File>Open Project > Seleccionamos dentro de API la solución.

### Paso 8: Ejecutar

  Luego de ejecutar la API, se nos abrira el Swagger UI, con los controllers de Actividades y de Foro.
