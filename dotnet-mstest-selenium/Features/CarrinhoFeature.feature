Funcionalidade: Carrinho
	
Esquema do Cenário: Finalizar carrinho
	Dado que o usuário esteja na página de login
	Quando informar suas credenciais de acesso corretamente
	Dado que o usuário adcionou "<quantidade>" produto no carrinho
	E está na pagina do carrinho de compras
	Quando Clicar no botão de checkout
	Entao o sistema solicitará os dados de entrega

	Exemplos: 
		| quantidade    |
		| Um produto    |
		| Três produtos |



Cenário: Comprar com carrinho vazio
	Dado que o usuário esteja na página de login
	Quando informar suas credenciais de acesso corretamente
	Dado que o usuário não adcionou produtos no carrinho
	E está na pagina do carrinho de compras
	Quando Clicar no botão de checkout
	Entao o sistema não solicitará os dados de entrega