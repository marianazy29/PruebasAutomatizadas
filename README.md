# Proyecto Final del Módulo 6 - Pruebas Automatizadas
# Plataforma de testing: https://practicesoftwaretesting.com

# Módulo de Login

## Casos de Prueba Implementados

## Autor
- **Nombre:** Edwin Ajahuanca Callisaya
- **Fecha:** Agosto 2025  

## Objetivo
El objetivo principal es **validar la funcionalidad del login** en el sistema `Practice Software Testing`, verificando:  
- Que usuarios válidos puedan autenticarse y acceder al dashboard.  
- Que credenciales inválidas sean rechazadas correctamente.  
- Que el tiempo de respuesta de la autenticación cumpla con los criterios no funcionales definidos.  

## Técnicas de Pruebas Utilizadas
- **Particionamiento de Equivalencias**: Usuarios válidos, inválidos e inexistentes.  
- **Análisis de Valores Límite (Boundary Value Analysis)**: Validación de longitud de contraseña y formato de email.  
- **Pruebas de Rendimiento**: Tiempo de respuesta medido con JMeter e Insomnia.  
- **Pruebas Funcionales Manuales y Automatizadas**: Con Selenium WebDriver (C# en Visual Studio).  

## Requerimientos Probados

### Requerimiento Funcional
> El sistema debe permitir que un usuario registrado ingrese su correo electrónico y contraseña en el formulario de login y al hacer clic en el botón **Login**, autentique los datos contra la base de usuarios.  
> Si las credenciales son correctas, el sistema debe redirigir al **dashboard** correspondiente a su rol.

### Requerimiento No Funcional
> El sistema debe procesar la autenticación de un usuario válido en un **tiempo máximo de 3 segundos**, bajo condiciones normales de operación.  
> El tiempo de respuesta debe medirse desde el **envío de la solicitud de login** hasta la **carga completa del dashboard**.  

## [Casos de Prueba](/PruebasAutomatizadas/Pruebas%20de%20Sistema/LoginTest/readme.md)

1. **TC-RF-LG-01 Login exitoso con credenciales válidas**  
   - Entrada: `admin@practicesoftwaretesting.com / welcome01`  
   - Esperado: Redirección al dashboard.  

2. **TC-RF-LG-02 Login fallido con contraseña incorrecta**  
   - Entrada: `admin@practicesoftwaretesting.com / welcome123`  
   - Esperado: Mensaje de error *"Invalid email or password"*.  

3. **TC-RF-LG-03 Login fallido con usuario inexistente**  
   - Entrada: `userfake@test.com / 123456`  
   - Esperado: Mensaje de error *"Invalid email or password"*.  

4. **TC-RF-LG-04 Validación de campos obligatorios y formato**  
   - Entrada: Campos vacíos, email inválido, password corto.  
   - Esperado: Mensajes de validación en la UI.  

5. **TC-RNF-LG-01 Tiempo de respuesta individual**  
   - Entrada: Usuario válido.  
   - Esperado: Autenticación completada en ≤ 3 segundos. (Con insomnia) 

6. **TC-RNF-LG-02 Tiempo de respuesta bajo carga concurrente (10 usuarios)**  
   - Herramienta: JMeter.  
   - Esperado: 95% de logins exitosos ≤ 3 segundos.  

## Herramientas Usadas
- **Visual Studio 2022** con **.NET 6**  
- **C# + Selenium WebDriver** (automatización UI)  
- **Insomnia** (pruebas de API, validación de respuestas y tiempos individuales)  
- **Apache JMeter** (pruebas de carga y rendimiento concurrente)  

## Características
- Pruebas funcionales (manuales y automatizadas).  
- Pruebas de validación de campos (UI).  
- Pruebas de rendimiento (API y UI).


# Módulo de Contacto

## Casos de Prueba Implementados

### [RF-CT-002: Envío de Mensaje con Datos Válidos](./PruebasAutomatizadas/Pruebas%20de%20Sistema/RF-CT-002/RF-CT-002.md)

**Autor:** Neyber Rojas Zapata  
**Técnica:** Particionamiento de Equivalencias - Datos Válidos  
**Objetivo:** Verificar que se puede enviar un mensaje de contacto con datos válidos exitosamente

**Características:**
- ✅ Autenticación automática de usuario
- ✅ Llenado de formulario con datos válidos
- ✅ Validación de envío exitoso
- ✅ Detección de mensajes de confirmación
- ✅ Manejo robusto de Angular SPA

### [RF-CT-003: Validación de Campos Vacíos](./PruebasAutomatizadas/Pruebas%20de%20Sistema/RF-CT-003/RF-CT-003.md)

**Autor:** Neyber Rojas Zapata  
**Técnica:** Particionamiento de Equivalencias - Datos Inválidos  
**Objetivo:** Verificar la validación cuando los campos requeridos están vacíos

**Características:**
- ✅ Validación de campos vacíos
- ✅ Detección de mensajes de error
- ✅ Validación HTML5 nativa
- ✅ Pruebas individuales por campo
- ✅ Estados ARIA para accesibilidad

### [RF-CT-001: Validación de Formato del Archivo Adjunto](./PruebasAutomatizadas/Pruebas%20de%20Sistema/RF-CT-001/readme.md)

**Autor:** Mariana Zúñiga Yáñez  
**Técnica:** Particionamiento de Equivalencias - Datos Inválidos y Datos Inválidos
**Objetivo:** Verificar el formato correcto del archivo adjunto en el formulario.

**Características:**
- ✅ Validación de formato válido (.txt).
- ✅ Validación de formaro inválido (.pdf).
- ✅ Verificar mensaje de éxito al enviar el formulario.
- ✅ Verificar mensaje de error al adjuntar un archivo inválido.