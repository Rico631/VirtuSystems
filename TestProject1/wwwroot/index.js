class RowUpdate extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      id: props.user.id,
      fio: props.user.fio,
      birthDate: props.user.birthDate,
      phone: this.phoneParser(props.user.phone),
    }
    this.phoneParser = this.phoneParser.bind(this)
  }

  render() {
    return (
      <tr>
        <td><input placeholder="FirstName" value={this.state.fio} onChange={(e) => this.setState({ fio: e.target.value })} /></td>
        <td><input placeholder="BirthDate" type="datetime-local" value={this.state.birthDate} onChange={(e) => this.setState({ birthDate: e.target.value })} /></td>
        <td><input placeholder="(555) 555-5555" value={this.state.phone} onChange={(e) => this.setState({ phone: this.phoneParser(e.target.value) })} /></td>
        <td>
          <button type="button" className="button"
            onClick={() => {
              let user = {
                id: this.state.id,
                fio: this.state.fio,
                birthDate: this.state.birthDate,
                phone: this.state.phone.replace(/[\(\) -]/gm, "")
              }

              if (user.fio.length == 0)
                return;

              if (this.props.user)
                user.id = this.props.user.id
              this.props.onUpdate(user)
              this.props.editFormSwitch()
            }}><span className="material-icons">done</span></button>
          <button type="button" className="button ms-2" onClick={this.props.editFormSwitch} ><span className="material-icons">close</span></button>
        </td>
      </tr>
    )
  }

  phoneParser(value) {
    let x = value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    let phone = !x[2] ? x[1] : '(' + x[1] + ') ' + x[2] + (x[3] ? '-' + x[3] : '');
    return phone;
  }
}

class Row extends React.Component {
  user = this.props.user
  constructor(props) {
    super(props)
    this.state = {
      editForm: props.editForm,
    }
    this.editFormSwitch = this.editFormSwitch.bind(this)
  }

  render() {
    if (this.state.editForm) {
      return (
        <RowUpdate
          editFormSwitch={this.editFormSwitch}
          onUpdate={this.props.onUpdate}
          user={this.props.user} />
      )
    }
    else
      return (
        <tr>
          <td>{this.user.fio}</td>
          <td>{this.user.birthDate}</td>
          <td>{this.phoneParser(this.user.phone)}</td>
          <td>
            <button type="button" className="button" onClick={this.editFormSwitch}><span className="material-icons">edit</span></button>
            <button type="button" className="button ms-2" onClick={() => this.props.onRemove(this.user)}><span className="material-icons">delete</span></button>
          </td>
        </tr>
      )
  }

  phoneParser(value) {
    let x = value.replace(/\D/g, '').match(/(\d{0,3})(\d{0,3})(\d{0,4})/);
    let phone = !x[2] ? x[1] : '(' + x[1] + ') ' + x[2] + (x[3] ? '-' + x[3] : '');
    return phone;
  }

  editFormSwitch() {
    this.setState({ editForm: !this.state.editForm })

    if (this.user.id == 0) {
      this.props.onRemove(this.user)
    }
  }

}

class Table extends React.Component {
  constructor(props) {
    super(props)
    this.loadUsers()
    this.state = {
      users: []
    }
    this.onUpdate = this.onUpdate.bind(this)
    this.onRemove = this.onRemove.bind(this)
    this.loadUsers = this.loadUsers.bind(this)
  }

  render() {
    return (
      <div>
        <button type="button" className="button"
          onClick={() => {
            let user = {
              id: 0,
              fio: "",
              birthDate: "",
              phone: ""
            }
            if (this.state.users.filter(x => x.id == 0) == 0)
              this.setState({ users: [...this.state.users, user] })
          }}><span className="material-icons">add</span></button>
        <table className="table">
          <thead>
            <tr>
              <td>FIO</td>
              <td>BirthDate</td>
              <td>Phone</td>
              <td></td>
            </tr>
          </thead>
          <tbody>
            {this.state.users.map((user, i) => (
              <Row key={i} user={user}
                editForm={user.id == 0}
                onUpdate={this.onUpdate}
                onRemove={this.onRemove} />
            ))}
          </tbody>
        </table>
      </div>
    )
  }

  onUpdate(user) {
    let method;
    if (user.id > 0)
      method = fetch(`/api/users/${user.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user)
      })
    else
      method = fetch(`/api/users`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user)
      })
    method.then(() => this.loadUsers())
  }

  onRemove(user) {
    if (user.id == 0)
      this.setState({ users: this.state.users.filter(x => x.id !== user.id) })
    else
      fetch(`/api/users/${user.id}`, { method: "DELETE" }).then(() => this.loadUsers())
  }

  loadUsers() {
    fetch("/api/users")
      .then(x => x.json())
      .then((res) => {
        this.setState({ users: [] }, () => {
          this.setState({ users: res })
        })
      })
  }

}

const e = React.createElement;
const domContainer = document.querySelector('#app');
const root = ReactDOM.createRoot(domContainer);
root.render(e(Table));