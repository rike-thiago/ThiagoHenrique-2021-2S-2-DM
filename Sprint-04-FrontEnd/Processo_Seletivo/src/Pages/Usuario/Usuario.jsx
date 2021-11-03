import { Component } from "react";
import '../Home/App.css';


export default class Usuario extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nomeUsuario: "",
            listaRepositories: [],
            idUser: 0,
            titulo: '',
            descricao: '',
            dataCriacao: '',
            tamanho: 0
        }
    }

    atualizaNomeUser = async (event) => {
        console.log("Digitando")

        await this.setState({
            nomeUsuario: event.target.value
        });

        console.log(this.state.nomeUsuario);
    }

    buscarUsuario = async (event) => {

        event.preventDefault()

        console.log('Iniciando app')

        fetch(`https://api.github.com/users/${this.state.nomeUsuario}/repos`)

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaRepositories: dados }))

            .catch(erro => console.log(erro))

        await console.log(this.state.listaRepositories)
    }

    componentDidMount() { }

    componentWillUnmount() { }

    render() {
        return (
            <div>
                <main>
                    <section>
                        <h1 className="Title">Insira o nome de Usuário para pesquisar seus repositórios</h1>
                        <form onSubmit={this.buscarUsuario} className="formulario">
                            <input onChange={this.atualizaNomeUser} type="text" placeholder="Insira um usuário" />
                            <button type="submit" disable={this.state.nomeUsuario === '' ? 'none' : ''}>Procurar</button>
                        </form>
                    </section>

                    <section className="trd">
                        {/* <h2>Lista de Repositórios do usuário {nomeUsuario}</h2> */}
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Nome</th>
                                    <th>Descrição</th>
                                    <th>Data de criação</th>
                                    <th>Tamanho</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaRepositories.map((user) => {
                                        //console.log(user)
                                        return (
                                            <tr>
                                                <td>{user.id}</td>
                                                <td>{user.name}</td>
                                                <td>{user.description}</td>
                                                <td>{user.created_at}</td>
                                                <td>{user.size}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
    }
}

