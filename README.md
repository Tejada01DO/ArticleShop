# ArticleShop
Este proyecto cuenta con un login donde se encuentran registrado varios usuarios, los cuales son: Administrador, Empleado y Estudiante, la forma de poder acceder a cada usuario es:

Administrador:
Correo: admin@gmail.com
contraseña: admin

Empleado:
Correo: empleado@gmail.com
contraseña: nuevoEmpleado

Estudiante:
Correo: estudiante@gmail.com
contraseña: nuevoEstudiante

Tanto el administrador como el empleado tienen permisos de ver todos los registros como las consultas pero el estudiante solo tiene permisos para visualizar el Registro de Ventas llamado Tienda de Articulos y Articulos Comprados

Registros:

R_Estudiantes: Se le puede llamar Registros de Ventas donde los estudiantes compran sus articulos, al momento del estudiante compra los articulos se le restan a los Articulos Disponibles.

R_Compras: Donde la tienda de articulos en caso de que quiera comprar articulos o los articulos esten en cero tengan la oportunidad de volver a cargar la cantidad de articulos existentes.

R_Articulos: Donde la tienda puede comprar articulos que no esten en la tienda, estos se agregan a la base de datos de la lista de articulos.

Consultas:

C_Estudiantes: Donde se guardan todos los datos de la compra que hizo el estudiante (venta de la tienda), cuenta con una opcion de ver que te lleva directamente al Registro de Ventas con todos sus datos.

C_Compras: Donde se guardan todos los datos de la compra que hizo la tienda al momento de comprar articulos.

C_Articulos: Donde se encuentra la lista de todos los articulos disponibles, aqui se podran visualizar cuando se restan los articulos (Registro de Ventas) y cuando se suman (Registro de Compras).
