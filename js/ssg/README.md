# Static Site Generator (SSG)

## Nuxt.js

- Based on Vue
- Can use Vuetify
- Can use as headless CMS
- Support Markdown, CSV, XML, YAML, JSON as content source
- Also can connect to external API
- Easy to kickstart
- A better way to build web
- A framework on top of another framework
- SSR (via node) and SSG mode

### [Installation](https://nuxtjs.org/docs/get-started/installation)

1. create-nuxt-app

`yarn create nuxt-app <project_name>`

`yarn dev`

2. from scratch

`mkdir project_dir`

`cd project_dir`

`touch package.json`

```json
{
  "name": "my-app",
  "scripts": {
    "dev": "nuxt",
    "build": "nuxt build",
    "generate": "nuxt generate",
    "start": "nuxt start"
  }
}
```
`yarn add nuxt`

`mkdir pages`

`touch pages/index.vue`

```html
<template>
  <h1>Hello world!</h1>
</template>
```

`yarn dev`
