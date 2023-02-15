pipeline {
    agent {
        docker {
            image 'node:14-alpine'
            args '--user node'
        }
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
                bat 'docker-compose -f C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml up --build -d'
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
