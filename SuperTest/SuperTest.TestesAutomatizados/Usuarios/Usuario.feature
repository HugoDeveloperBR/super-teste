Feature: Cadastrar novo usuario 

Scenario: Impedir cadastro de um usuario so com espacos em branco no campo nome
	Given Um nome em com espacos em branco
	And Um email valido
	And Um CPF valido
	And Uma senha com mais de 6 caracteres
	When Chamo o metodo CadastrarUsuario
	Then Recebo a mensagem "Nome não pode ser vazio"
