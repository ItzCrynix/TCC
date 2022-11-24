Como rodar nosso projeto do Unity:

1º método:

- Dentro da pasta do projeto, foi criado um arquivo executável e funcional do jogo, chamado Discovering the Abyss, 
sendo assim o jeito mais fácil de rodar o programa.

2º método:

- Caso queira entrar no modo de editar do próprio unity, é aconselhável que se utilize a versão do unity 2021.3.4f1
- É possível que caso você entre em outra versão, o projeto apareça totalmente em rosa, isso ocorre devido à tentativa
do projeto utilizar um Renderer Pipeline incompatível, deste modo, será necessário instalar o Renderer Pipeline da
versão que está sendo utilizada no Unity.
- Para fazer isso, entre em Window > Package Manager, e pesquise no Unity Registry "Pipeline", dependendo de qual versão
você esteja usando o nome pode variar, podendo ser, Lightweigth Pipeline, Universal Pipeline, UPR, entre outros.
- Após a instalação, é necessário criar os renderers respectivos do pacote que acabou de ser instalado, na aba de
"Create" do Unity, procure por rendering e crie um 2D Renderer e um Forward Renderer, ao fazer isso, eles já estarão
relacionados entre si, faltando apenas ir nas "Project Settings" e arrastar um dos arquivos do Pipeline para o campo
que pede um Pipeline compatível.
- Pode ser que seja necessário também converter os materiais do projeto para objetos do Pipeline, na aba Edit > Rendering >
Material > Convert Materials.
- Se mesmo após todos esses passos não foi possível consertar a tela rosa, é recomendado executar o aplicativo do jogo na pasta,
com o nome Discovering the Abyss, ou abrir o projeto na versão 2021.3.4f1.
