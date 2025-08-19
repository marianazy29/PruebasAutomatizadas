# Pruebas Automatizadas - Módulo de Contacto

Este proyecto contiene pruebas automatizadas para validar el funcionamiento del formulario de Contacto en el sitio web [Practice Software Testing](https://practicesoftwaretesting.com/contact), utilizando **C#**, **Selenium WebDriver** y **MSTest**.

## 📌 Objetivo

Verificar que el formulario de contacto del sitio web:
1. Permita enviar información correctamente cuando se ingresan datos válidos y se adjunta un archivo con extensión `.txt`.
2. Muestre un mensaje de error cuando se intente adjuntar un archivo con una extensión no permitida (`.pdf`).

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework de pruebas:** MSTest
- **Automatización web:** Selenium WebDriver
- **Navegador utilizado:** Google Chrome

---

## ⚙️ Configuración previa

1. Instalar **Google Chrome** en la computadora.
2. Instalar el paquete **Selenium WebDriver** en el proyecto

Instalar el driver de ChromeDriver compatible con la versión de Chrome instalada:

Las rutas que se utilziaron en este proyecto, deben ser reemplazadas de acuerdo a la ruta de su computadora local.

**C:\Users\Mariana\Documents\archivoVacio.txt**

**C:\Users\Mariana\Documents\archivoPdf.pdf**

## ▶️ Ejecución de pruebas
Abrir el proyecto en Visual Studio.

Compilar la solución.

Ejecutar las pruebas desde:

El Test Explorer de Visual Studio

## 📋 Casos de prueba implementados
1. Contacto_DatosYAdjuntoValidos_MuestraMensajeExitoso
✅ Flujo correcto del formulario:

Completar campos obligatorios con datos válidos.

Adjuntar un archivo .txt.

Verificar que se muestre el mensaje:

**Thanks for your message! We will contact you shortly.**

Capturas de pantalla: Formulario_Completado.png, Mensaje_Exito.png



2. Contacto_DatosVálidosYAdjuntoInValidos_MuestraMensajeDeError
❌ Flujo inválido del formulario:

Completar campos obligatorios con datos válidos.

Adjuntar un archivo .pdf.

Verificar que se muestre el mensaje:

**File should have a txt extension.**

Capturas de pantalla:Formulario_CompletadoV2.png, Mensaje_Error.png

👩‍💻 Autor
Mariana Zúñiga Yáñez