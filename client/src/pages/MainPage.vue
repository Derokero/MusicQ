<template>
  <div class="app-container">
    <header class="header">
      <div class="logo">MeowSic 🐾</div>
      <div class="room-info">Room: Placeholder</div>
    </header>

    <div class="layout-grid">
      <aside class="sidebar-users">
        <h3>Listeners</h3>
        <ul class="placeholder-list">
          <li v-for="n in 3" :key="n">
            <img src="https://cataas.com/cat?width=20" alt="cat" />
            User_{{ n }}
          </li>
        </ul>
      </aside>

      <main class="main-content">
        <section class="player-section">
          <img src="https://cataas.com/cat/says/Now%20Playing" alt="Current Song" />
          <div class="controls">
            <button>Play/Pause</button>
            <button>Skip</button>
          </div>
        </section>

        <section class="queue-section">
          <h3>Queue</h3>
          <div v-for="n in 3" :key="n" class="queue-item">
            <span>Song Title {{ n }}</span>
            <div class="actions">
              <button>▲ Up</button>
              <button>▼ Down</button>
              <button>🗑️</button>
            </div>
          </div>
        </section>
      </main>

      <aside class="sidebar-library">
        <h3>Add Songs</h3>
        <input type="text" placeholder="Search..." />
        <ul class="placeholder-list">
          <li v-for="n in 5" :key="n">
            Track {{ n }}
            <button>+</button>
          </li>
        </ul>
      </aside>
    </div>
  </div>
</template>

<style scoped>
.app-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  font-family: sans-serif;
}

.header {
  padding: 1rem;
  border-bottom: 1px solid #ccc;
  display: flex;
  justify-content: space-between;
}

.layout-grid {
  display: grid;
  grid-template-columns: 200px 1fr 250px;
  flex: 1;
  overflow: hidden;
}

.sidebar-users,
.sidebar-library,
.main-content {
  padding: 1rem;
  border-right: 1px solid #eee;
  overflow-y: auto;
}

.player-section {
  text-align: center;
  padding-bottom: 2rem;
  border-bottom: 1px solid #eee;
}

.queue-item {
  display: flex;
  justify-content: space-between;
  padding: 0.5rem 0;
  border-bottom: 1px solid #fafafa;
}

.actions {
  display: flex;
  gap: 4px;
}

.placeholder-list {
  list-style: none;
  padding: 0;
}

.placeholder-list li {
  display: flex;
  align-items: center;
  gap: 8px;
  margin-bottom: 10px;
}
</style>