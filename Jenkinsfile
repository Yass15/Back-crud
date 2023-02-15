pipeline {
    agent any

    environment{
        COMPOSE_FILE = 'C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml'
    }
    
    triggers {
        githubPush()
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                bat 'docker-compose -f ${env.COMPOSE_FILE} up --build -d sql_server'
                bat 'docker-compose -f ${env.COMPOSE_FILE} up --build -d frontend'
                bat 'docker-compose -f ${env.COMPOSE_FILE} up --build -d backend'
            }
        }
    }

    post {
        success {
            bat 'echo "success"'
        }
        failure {
            bat 'echo "Build failed"'
        }
    }
}
