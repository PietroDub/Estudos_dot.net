import { useState } from "react";

export default function Index() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const user = {
      name: name,
      email: email
    };

    fetch("https://localhost:7003/api/users")
    .then(res => console.log(res))
    .catch(err => console.error(err));

    const response = await fetch("https://localhost:7003/api/Users", {
      method: "POST", // 🔥 tipo da requisição
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(user) // 🔥 convertendo pra JSON
    });

    const data = await response.json();

    console.log("Resposta da API:", data);
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        placeholder="Nome"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <input
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <button type="submit">Cadastrar</button>
    </form>
  );
}
