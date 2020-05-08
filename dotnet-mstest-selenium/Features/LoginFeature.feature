Funcionalidade: Login
	
	Cenário: Login com sucesso
		Dado que o usuário esteja na página de login
		Quando informar suas credenciais de acesso corretamente
		Entao o sistema apresentará tela de produtos
	
	Esquema do Cenário: Login incorreto
		Dado que o usuário esteja na página de login
		Quando informar suas credenciais de acesso "<incorretamente>"
		Então uma mensagem será exibida informando o erro

		Exemplos: 
		| incorretamente    |
		| username vazio    |
		| username inválido |
		| senha vazia       |
		| senha inválida    |


	@TesteDevice
	Esquema do Cenário: Variação de dispositivo Mobile
		Dado que o usuário esteja utilizando "<device>"
		Quando informar suas credenciais de acesso corretamente
		Entao o sistema apresentará tela de produtos

		Exemplos: 
		| device            |
		| Galaxy s5         |
		| iPhone 6/7/8 Plus |
		| Pixel 2           |

