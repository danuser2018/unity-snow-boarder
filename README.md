[![Build & Deploy](https://github.com/danuser2018/unity-snow-boarder/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/danuser2018/unity-snow-boarder/actions/workflows/build.yml)

# Snow Boarder

Proyecto creado para el curso de Unity 2D de Udemy.

El proyecto tiene configurado un flujo de ci/cd completo: Al subir las PRs ejecuta los tests del proyecto. Cuando se completa la PR, el proyecto se construye automáticamente y se despliega a heroku. Puedes acceder a la [última versión desplegada aquí](https://danuser2018-snow-boarder.herokuapp.com).

Ten en cuenta que para la ejecución del CI/CD es necesario correr una licencia independiente de Unity, distinta de la que usas para el IDE de desarrollo.

Incluye algunas características que me han parecido interesantes:

- [Configuración de GIT](https://unityatscale.com/unity-version-control-guide/how-to-setup-unity-project-on-github)
- [Integración continua con GameCI](https://game.ci)
- [Activación de la licencia UNITY y compilación](https://github.com/jcs090218/JCSUnity)
- [Despliegue en Heroku](https://github.com/jctaveras/heroku-deploy)

## Prerequisitos

- Cuenta de gmail para el juego. Se utilizará para la licencia de Unity y para el despliegue de heroku. Debe de estar configurada para [acceso IMAP](https://support.google.com/mail/answer/7126229?hl=es#zippy=) y permitir el acceso de [aplicaciones consideradas por google 'poco seguras'](https://support.google.com/accounts/answer/6010255?hl=es). 
- Unity id, para crear una licencia personal. La licencia debe ser distinta de la utiliza en el ID. Las licencias de Unity se conceden por máquina. En este caso se pedirá para el agente de GitHub que ejecutará las acciones.
- Cuenta gratuita de heroku, para los despliegues.
- Docker instalado, para ejecución local.

### Secretos necesarios para ejecutar las pipelines

- ACCESS_TOKEN: Necesaria para grabar automáticamente la licencia de Unity cuando se genere. Sólo debe contener el permiso public_repo. [¿Cómo crear un access token?](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)
- EMAIL_PASSWORD: Necesaria para la obtención de la licencia de Unity. La primera vez que se pide una licencia, Unity envía un correo de verificación. Para tener acceso a dicho correo, es necesario proveer el password. 
- HEROKU_API_KEY: Necesaria para ejecutar el despliegue en Heroku. La podrás encontrar en los settings de tu cuenta de Heroku.
- HEROKU_APP_NAME: Nombre de la aplicación que has creado para desplegar tu juego.
- HEROKU_EMAIL: Mail asociado a la cuenta de Heroku.
- UNITY_EMAIL: Mail asociado a la cuenta de Unity.
- UNITY_LICENSE: Se rellenará automáticamente como resultado de ejecutar la pipeline de 'License'.
- UNITY_PASSWORD: Password de la cuenta en Unity.

## Testing

El juego cuenta con un juego de tests básicos en 'edit mode'. Estos tests pueden ser corridos en local desde el IDE, o bien utilizando la pipeline de 'Tests'. En cualquier caso, siempre que se haga una PR a la rama 'main' los tests se correrán automáticamente.

Para poder definir tests debes [activar el framework de testing en Unity](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html)

Recuerda que para que tu código sea 'testable' deberás de generar un Assembly para tus clases, e incluir una referencia a dicho Assembly en el Assembly de tests.

## Compilación/Empaquetado

Compila en formato WebGL, lo que permite ejecutar en cualquier navegador. Hay que tener en cuenta que el formato de compresión que se utiliza por defecto (brotli) no es reconocido por todos los navegadores, por lo que es recomendable cambiar el modo de compresión a gzip. [Aquí puedes encontrar cómo hacerlo](https://docs.unity3d.com/Manual/webgl-deploying.html).

## Despliegue

Las compilaciones en WebGL necesitan ser servidas desde un servidor web. En este caso, he utilizado [nginx](https://www.nginx.com/). Para desplegar, se genera
una imagen Docker del proyecto, que se construye a partir de un Dockerfile que se encuentra en la raíz del proyecto. 

Este Dockerfile se construye a partir de la [imagen oficial de nginx](https://hub.docker.com/_/nginx/) y utiliza una variable de entorno denominada $PORT. Esta variable define el puerto de escucha de nginx. Es necesario que la imagen se construya así para que Heroku pueda definir el puerto que se utiliza (ver apartado de variables de entorno).

### Local

Para ejecutar el proyecto en local hay que seguir los siguientes pasos:

1. Compilar el proyecto con el IDE de Unity, en formato WebGL. La carpeta de destino debe ser 'build'.
2. Ejecutar 'docker-compose build' para generar la imagen.
3. Ejecutar 'docker-compose up -d' para levantar el servidor. 
4. El juego estará accesible en http://localhost:8080
5. Para parar el servidor, 'docker-compose down'.

### Heroku

Cuando se hace un push a la rama main, automáticamente salta una pipeline que construye y despliega el juego a Heroku.
Esta pipeline necesita:

- Que tengas configurada correctamente la licencia de Unity, para que se puede ejecutar el build. Antes de ejecutar esta acción necesitarás lanzar la acción de 'License' para obetenerla.
- Que tengas una aplicación creada en Heroku para el juego.

## Licencia

Este trabajo está bajo licencia MIT: 

The MIT License (MIT)

Copyright © 2022 danuser2018

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


