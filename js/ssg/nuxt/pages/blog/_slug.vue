<template>
    <article>
        <nuxt-content :document="article" />
        <p>Article last update: {{ formatDate(article.updatedAt )}}</p>
        <v-img :src="article.img1" contain width="200px" />
        <v-img :src="article.img2" contain width="200px" />
        <nav>
            <ul>
                <li v-for="link of article.toc" :key="link.id">
                    <nuxt-link :to="`#${link.id}`">{{ link.text }}</nuxt-link>
                </li>
            </ul>
        </nav>
        <pre>{{ article }}</pre>
    </article>
</template>
<script>
export default {
    async asyncData({$content, params}) {
        const article = await $content('articles', params.slug).fetch();

        return {article}
    },
    methods: {
        formatDate(date) {
            return new Date(date).toLocaleDateString('zh-HK', { year: 'numeric', month: 'long', day: 'numeric'})
        }
    },
}
</script>
<style>
  .nuxt-content h2 {
    font-weight: bold;
    font-size: 28px;
  }
  .nuxt-content h3 {
    font-weight: bold;
    font-size: 22px;
  }
  .nuxt-content p {
    margin-bottom: 20px;
  }
  .icon.icon-link {
  background-image: url('~assets/icon-hashtag.svg');
  display: inline-block;
  width: 20px;
  height: 20px;
  background-size: 20px 20px;
}
</style>