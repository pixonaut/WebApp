<script lang="ts">
    import { goto } from '$app/navigation';

    let username = '';
    let password = '';
    let message = '';

    async function login(event: SubmitEvent) {
        event.preventDefault();

        try {
            const res = await fetch('http://localhost:5000/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ username, password })
            });

            if (res.ok) {
                const data = await res.json();
                message = 'Login successful!';
                // redirect or store token as needed
                goto('/dashboard');
            } else {
                const err = await res.text();
                message = `Login failed: ${err}`;
            }
        } catch (err: any) {
            message = `Error: ${err.message}`;
        }
    }
</script>

<h1>Login</h1>

<form on:submit={login}>
    <div>
        <label for="username">Username:</label>
        <input id="username" bind:value={username} required />
    </div>

    <div>
        <label for="password">Password:</label>
        <input id="password" type="password" bind:value={password} required />
    </div>

    <button type="submit">Login</button>
</form>

<p>{message}</p>
